using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Setting;
using CV.Data.Enum;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Setting
{
    public class SearchService : ISearchService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SearchPage> _searchPageRepo;

        public SearchService(IMapper mapper, IRepository<SearchPage> searchPageRepo)
        {
            _mapper = mapper;
            _searchPageRepo = searchPageRepo;
        }

        public IEnumerable<SearchPageModel> GetAll(string filter, Languages? lang)
        {
            var query = _searchPageRepo.TableNoTracking.Where(x => x.Lang == lang.Value);

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));

            return query.ProjectTo<SearchPageModel>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
