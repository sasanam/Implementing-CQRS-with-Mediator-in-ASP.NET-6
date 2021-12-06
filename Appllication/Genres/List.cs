﻿using AutoMapper;
using Domain.Data;
using Domain.DTO;
using MediatR;

namespace Appllication.Genres;
public class List
{
    public class Query : IRequest<List<GenreDTO>>
    {
    }

    public class Handler : IRequestHandler<Query, List<GenreDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GenreDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Genres.GetAll());
            return _mapper.Map<List<GenreDTO>>(entities);
        }
    }
}
