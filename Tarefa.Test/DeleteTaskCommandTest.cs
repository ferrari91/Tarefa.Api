using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefa.Application.Features.Task.Update;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Application.Interface;
using Tarefa.Application.Features.Task.Delete;
using Xunit;
using Tarefa.Domain.Entities;
using Tarefa.Domain.Common;

namespace Tarefa.Test
{
    public class DeleteTaskCommandTest
    {
        private readonly Mock<ITaskRepository> _mockTaskRepository;
        private readonly Mock<IUnityOfWork> _mockUnitOfWork;
        private readonly DeleteTaskCommandHandler _handler;

        public DeleteTaskCommandTest()
        {
            _mockTaskRepository = new Mock<ITaskRepository>();
            _mockUnitOfWork = new Mock<IUnityOfWork>();
            _handler = new DeleteTaskCommandHandler(_mockTaskRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_Delete_Salvar_Sucesso()
        {
            var command = new DeleteTaskCommand { Id = 1 };
            var task = new TaskEntity { Id = 1 };

            _mockTaskRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(task);
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockTaskRepository.Verify(r => r.Delete(task), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_Delete_Nao_Contem_Registro()
        {
            // Arrange
            var command = new DeleteTaskCommand { Id = 1 };
            TaskEntity task = null;

            _mockTaskRepository.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(task);
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockTaskRepository.Verify(r => r.Delete(It.IsAny<TaskEntity>()), Times.Never);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_Validar_Task_Concluida_True()
        {
            // Arrange
            var command = new DeleteTaskCommand
            {
                Id = 1,
            };

            var taskEntity = new TaskEntity { Id = 1, Titulo = "Task 1", Concluida = true };
            _mockTaskRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(taskEntity);

            var validator = new DeleteTaskCommandValidator(_mockTaskRepository.Object);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.True(result.Errors.Count() == 0);
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_Validar_Task_Concluida_False()
        {
            // Arrange
            var command = new DeleteTaskCommand
            {
                Id = 1,
            };

            var taskEntity = new TaskEntity { Id = 1, Titulo = "Task 1", Concluida = false };
            _mockTaskRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(taskEntity);

            var validator = new DeleteTaskCommandValidator(_mockTaskRepository.Object);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "A Tarefa não foi encontrada ou não está concluída.");
        }
    }
}
