using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void TDelete(ImageFile t)
        {
            _imageFileDal.Delete(t);
        }

        public ImageFile TGetByID(int id)
        {
            return _imageFileDal.GetByID(id);
        }

        public List<ImageFile> TGetList()
        {
            return _imageFileDal.GetList();
        }

        public void TInsert(ImageFile t)
        {
            _imageFileDal.Insert(t);
        }

        public void TUpdate(ImageFile t)
        {
            _imageFileDal.Update(t);
        }
    }
}
