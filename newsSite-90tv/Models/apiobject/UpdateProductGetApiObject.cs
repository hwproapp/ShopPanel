using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class UpdateProductGetApiObject : AllApi
    {
        public UpdateProductGetApiModel product { get; set; }

        public List<Color> productColor { get; set; }

        public List<SizeApiModel> productSize { get; set; }

        public List<PropertyGetApiModel> properties { get; set; }


        public List<ImageApiModel> gallaryImages { get; set; }


        public IEnumerable<Category> categories { get; set; }

        public IEnumerable<ProductBrand> brands { get; set; }

        public IEnumerable<Color> colors { get; set; }



        // init first for prevent null error
        public UpdateProductGetApiObject()
        {
            properties = new List<PropertyGetApiModel>();
            product = new UpdateProductGetApiModel();
            productColor = new List<Color>();
            productSize = new List<SizeApiModel>();
            properties = new List<PropertyGetApiModel>();
            gallaryImages = new List<ImageApiModel>();
            categories = new List<Category>();
            brands = new List<ProductBrand>();

        }


    }

    public class UpdateProductGetApiModel
    {
        public long productId { get; set; }

       // public long shopId { get; set; }
       // public long sellerId { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public string desc { get; set; }

        public string indexImage { get; set; }

        public int categoryId { get; set; }

        public int brandId { get; set; }

        public int qty { get; set; }

        public int weight { get; set; }

        public long price { get; set; }

        public int offpercent { get; set; }

        public string garanty { get; set; }

    
    }


    public class PropertyGetApiModel
    {

        //public long ProductId { get; set; }

        public int PropertiesId { get; set; }

        public string PropertiesName { get; set; }

        public int PropertyValueId { get; set; }

        public string PropertiesValue { get; set; }
    }
}
