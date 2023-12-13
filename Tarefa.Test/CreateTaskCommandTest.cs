using Moq;
using Tarefa.Application.Features.Task.Create;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Entities;
using Xunit;

namespace Tarefa.Test
{
    public class CreateTaskCommandTest
    {
        [Fact]
        public void CreateTaskCommandHandler_Adicionar_e_Salvar_Sucesso()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Titulo = "Test Task",
                Concluida = false
            };

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockUnitOfWork = new Mock<IUnityOfWork>();

            var handler = new CreateTaskCommandHandler(mockTaskRepository.Object, mockUnitOfWork.Object);

            // Act
            var result = handler.Handle(command, CancellationToken.None).Result;

            // Assert
            mockTaskRepository.Verify(r => r.AddAsync(It.IsAny<TaskEntity>()), Times.Once);
            mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void CreateTaskCommandHandler_Adicionar_e_Salvar_Falha()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Titulo = "Test Task",
                Concluida = false
            };

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockUnitOfWork = new Mock<IUnityOfWork>();

            mockTaskRepository.Setup(r => r.AddAsync(It.IsAny<TaskEntity>())).Throws(new Exception("Failed to add task"));
            var handler = new CreateTaskCommandHandler(mockTaskRepository.Object, mockUnitOfWork.Object);

            Exception exception = null;
            try
            {
                var result = handler.Handle(command, CancellationToken.None).Result;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            mockTaskRepository.Verify(r => r.AddAsync(It.IsAny<TaskEntity>()), Times.Once);
            mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never); 
            Assert.NotNull(exception);
        }

        [Fact]
        public void CreateTaskCommandHandler_Validar_Titulo_Null()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Titulo = null,
                Concluida = false
            };

            var validator = new CreateTaskCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == "Titulo");
        }

        [Fact]
        public void CreateTaskCommandHandler_Validar_Titulo_Vazio()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Titulo = "",
                Concluida = false
            };

            var validator = new CreateTaskCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == "Titulo");
        }

        [Fact]
        public void CreateTaskCommandHandler_RepositoryAdd_Exception()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Titulo = "Test Task",
                Concluida = false
            };

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockUnitOfWork = new Mock<IUnityOfWork>();

            mockTaskRepository.Setup(r => r.AddAsync(It.IsAny<TaskEntity>())).ThrowsAsync(new Exception("Failed to add task"));

            var handler = new CreateTaskCommandHandler(mockTaskRepository.Object, mockUnitOfWork.Object);

            // Act and Assert
            Assert.Throws<AggregateException>(() => handler.Handle(command, CancellationToken.None).Result);
        }

        [Fact]
        public void CreateTaskCommandHandler_UnityOfWorkSave_Exception()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Titulo = "Test Task",
                Concluida = false
            };

            var mockTaskRepository = new Mock<ITaskRepository>();
            var mockUnitOfWork = new Mock<IUnityOfWork>();

            mockUnitOfWork.Setup(u => u.SaveChangesAsync()).ThrowsAsync(new Exception("Failed to save changes"));

            var handler = new CreateTaskCommandHandler(mockTaskRepository.Object, mockUnitOfWork.Object);

            // Act and Assert
            Assert.Throws<AggregateException>(() => handler.Handle(command, CancellationToken.None).Result);
        }
    }
}