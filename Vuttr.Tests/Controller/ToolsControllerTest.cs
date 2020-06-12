using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vuttr.API.Controllers;
using Vuttr.API.Domain.DTO.Tool;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;
using Vuttr.API.Domain.RequestFeatures;
using Vuttr.API.LoggerService;
using Xunit;

namespace Vuttr.Tests.Controller
{
    public class ToolsControllerTest
    {
        private readonly ToolsController _controller;
        private readonly Mock<IToolRepository> _mockRepository;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public ToolsControllerTest()
        {
            _mockRepository = new Mock<IToolRepository>();
            _mockLogger = new Mock<ILoggerManager>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ToolsController(_mockRepository.Object, _mockLogger.Object, _mockMapper.Object, _mockUnitOfWork.Object );
        }
        
        /*[Fact]
        public void GetTools_WhenCalled_ReturnsOkResult()
        {
            var toolParameters = new ToolParameters();
            var okResult = _controller.GetTools(toolParameters);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }*/
    }
}