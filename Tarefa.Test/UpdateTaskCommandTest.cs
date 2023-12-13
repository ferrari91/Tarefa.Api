using Moq;
using Tarefa.Application.Features.Task.Create;
using Tarefa.Application.Features.Task.Update;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Entities;
using Xunit;
using Xunit.Abstractions;

namespace Tarefa.Test
{
    public class UpdateTaskCommandTest
    {
        private readonly Mock<ITaskRepository> _mockTaskRepository;
        private readonly Mock<IUnityOfWork> _mockUnitOfWork;
        private readonly UpdateTaskCommandHandler _handler;

        public UpdateTaskCommandTest()
        {
            _mockTaskRepository = new Mock<ITaskRepository>();
            _mockUnitOfWork = new Mock<IUnityOfWork>();
            _handler = new UpdateTaskCommandHandler(_mockTaskRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_Update_Salvar_Sucesso()
        {
            // Arrange
            var command = new UpdateTaskCommand();
            var cancellationToken = new CancellationToken();

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            _mockTaskRepository.Verify(r => r.Update(command), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void UpdateTaskCommandHandler_Adicionar_e_Salvar_Falha()
        {
            // Arrange
            var command = new UpdateTaskCommand
            {
                Id = 1,
                Titulo = "Test Task",
                Concluida = false
            };

            _mockTaskRepository.Setup(r => r.Update(It.IsAny<TaskEntity>())).Throws(new Exception("Failed to add task"));

            Exception exception = null;
            try
            {
                var result = _handler.Handle(command, CancellationToken.None).Result;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            _mockTaskRepository.Verify(r => r.Update(It.IsAny<TaskEntity>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_Validar_Task_Concluida_True()
        {
            // Arrange
            var command = new UpdateTaskCommand
            {
                Id = 1,
                Titulo = null,
                Concluida = true
            };

            var taskEntity = new TaskEntity { Id = 1, Titulo = "Task 1", Concluida = true };
            _mockTaskRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(taskEntity);

            var validator = new UpdateTaskCommandValidator(_mockTaskRepository.Object);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Somente tarefas não concluídas podem receber alteração.");
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_Validar_Task_Concluida_False()
        {
            // Arrange
            var command = new UpdateTaskCommand
            {
                Id = 1,
                Titulo = null,
                Concluida = true
            };

            var taskEntity = new TaskEntity { Id = 1, Titulo = "Task 1", Concluida = false };
            _mockTaskRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(taskEntity);

            var validator = new UpdateTaskCommandValidator(_mockTaskRepository.Object);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.True(result.Errors.Count() == 0);
        }

        [Fact]
        public void UpdateTaskCommandHandler_RepositoryUpdate_Exception()
        {
            // Arrange
            var command = new UpdateTaskCommand
            {
                Id = 1,
                Titulo = null,
                Concluida = true
            };

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockUnitOfWork = new Mock<IUnityOfWork>();

            mockTaskRepository.Setup(r => r.Update(It.IsAny<TaskEntity>())).Throws(new Exception("Failed to update task"));

            var handler = new UpdateTaskCommandHandler(mockTaskRepository.Object, mockUnitOfWork.Object);

            //Assert
            Assert.Throws<AggregateException>(() => handler.Handle(command, CancellationToken.None).Result);
        }

        [Fact]
        public void UpdateTaskCommandHandler_UnityOfWorkSave_Exception()
        {
            // Arrange
            var command = new UpdateTaskCommand
            {
                Id = 1,
                Titulo = null,
                Concluida = true
            };

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockUnitOfWork = new Mock<IUnityOfWork>();

            mockUnitOfWork.Setup(u => u.SaveChangesAsync()).ThrowsAsync(new Exception("Failed to save changes"));

            var handler = new UpdateTaskCommandHandler(mockTaskRepository.Object, mockUnitOfWork.Object);

            //Assert
            Assert.Throws<AggregateException>(() => handler.Handle(command, CancellationToken.None).Result);
        }
    }
}