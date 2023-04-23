using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.CaregoryRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.CategoryResponseModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class CategoryService : BaseService<Category,CategoryResponseModel,CategoryRequestModel>, ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public override CategoryResponseModel Create(CategoryRequestModel categoryRequest)
        {
            var categoryCreateRequest = categoryRequest as CreateCategoryRequestModel;
            var entity = _mapper.Map<CreateCategoryRequestModel, Category>(categoryCreateRequest);
            _categoryRepository.Add(entity);
            _categoryRepository.SaveChanges();
            return _mapper.Map<Category, CreateCategoryResponseModel>(entity);
        }
        public override CategoryResponseModel Get(ulong id)
        {
            return _mapper.Map<Category, GetCategoryResponseModel>(_categoryRepository.GetById(id));
        }

        public override IEnumerable<CategoryResponseModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GetCategoryResponseModel>>(_categoryRepository.GetAll());
        }

        public override CategoryResponseModel Update(CategoryRequestModel categoryRequestModel, ulong id)
        {
            var category = _categoryRepository.GetById(id);
            var updateCategoryRequest = categoryRequestModel as UpdateCategoryRequestModel;
            _mapper.Map<UpdateCategoryRequestModel, Category>(updateCategoryRequest);
            _categoryRepository.Update(category, id);
            _categoryRepository.SaveChanges();
            return _mapper.Map<Category, UpdateCategoryResponseModel>(category);
        }
        public override bool Delete(ulong id)
        {
            var result = _categoryRepository.GetById(id);
            if (result != null)
            {
                _categoryRepository.Delete(result);
                _categoryRepository.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
