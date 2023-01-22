using Lingo.Services;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Lingo.Data;
using Lingo.Dtos;
using Lingo.Models;
using AutoMapper;

namespace Lingo.Tests;
public class UnitTest1
    {
        private readonly IGameRepo _gameRepo;
        private readonly IGameWordRepo _gameWordRepo;
        private readonly IFinalWordService _finalWordService;
        private readonly IWordService _wordService;
        private readonly IGameWordService _gameWordService;
        private readonly LingoContext _context;
        public IMapper _mapper { get; }
        
        public UnitTest1(IGameRepo gameRepo, IGameWordRepo gameWordRepo, IFinalWordService finalWordService, IWordService wordService, IGameWordService gameWordService, IMapper mapper, LingoContext context) {
            _gameRepo = gameRepo;
            _gameWordRepo = gameWordRepo;
            _finalWordService = finalWordService;
            _wordService = wordService;
            _gameWordService = gameWordService;
            _mapper = mapper;
            _context = context;
        }
        
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var gameService = new GameService();
            int result = gameService.testen();

            Assert.Equal(result, 5);
        }
    }
