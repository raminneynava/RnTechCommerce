using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _Framework.Application;

using _FrameWork.Application;

using ShopManagement.Application.Contracts.Slider;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Application
{
    public class SliderApplication : ISliderApplication
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderApplication(ISliderRepository repository)
        {
            _sliderRepository = repository;
        }
        public async Task<OperationResult> Create(CreateSlider Command)
        {
            var Slider = new Slider(
                Command.Name,
                Command.TitleOne,
                Command.TitleTwo,
                Command.Picture,
                Command.PictureAlt,
                Command.PictureTitle,
                Command.Order);
            await _sliderRepository.Create(Slider);
            await _sliderRepository.SaveChangesAsync();

            return new OperationResult().Succedded();

        }

        public async Task<OperationResult> Disable(long id)
        {
            var slider = await _sliderRepository.Get(id);
            if (slider == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slider.Desable();
            await _sliderRepository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Edit(EditSlider Command)
        {
            var slider = await _sliderRepository.Get(Command.Id);
            if (slider == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slider.Edit(
                Command.Name,
                Command.TitleOne,
                Command.TitleTwo,
                Command.Picture,
                Command.PictureAlt,
                Command.PictureTitle,
                Command.Order
                );
            await _sliderRepository.SaveChangesAsync();

            return new OperationResult().Succedded();
        }

        public async Task<OperationResult> Enable(long id)
        {
            var slider = await _sliderRepository.Get(id);
            if (slider == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slider.Enable();
            await _sliderRepository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }

        public async Task<EditSlider> GetById(long id)
        {
            return await _sliderRepository.GetById(id);
        }

        public async Task<IEnumerable<SliderViewModel>> GetList()
        {
            return await _sliderRepository.GetList();
        }

        public async Task<OperationResult> Remove(long id)
        {
            var slider = await _sliderRepository.Get(id);
            if (slider == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slider.Removed();
            await _sliderRepository.SaveChangesAsync();
            return new OperationResult().Succedded();
        }
    }
}
