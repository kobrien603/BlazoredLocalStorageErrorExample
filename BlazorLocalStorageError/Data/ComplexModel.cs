namespace BlazorLocalStorageError.Data
{
    public class ComplexModel
    {
        public Dictionary<string, List<Dict1Object>> Dict1 { get; set; } = new ComplexModelService().FillDict1();
        public Dictionary<string, List<List<bool>>> Dict2 { get; set; } = new ComplexModelService().FillDict2();
        public Dictionary<string, List<List<bool>>> Dict3 { get; set; } = new ComplexModelService().FillDict2();
        //public Dictionary<string, List<List<bool>>> Dict3 { get; set; } = new();
        public List<int> IntList { get; set; } = new List<int>();
        public decimal? Decimal1 { get; set; }
        public decimal? Decimal2 { get; set; }
        public decimal? Decimal3 { get; set; }
        public decimal? Decimal4 { get; set; }
        public decimal? Decimal5 { get; set; }
        public bool Bool1 { get; set; }
        public string String1 { get; set; } = "";

        public Dictionary<int, ComplexModel> GetDefaultComplexModel()
        {
            const int DEFAULT_PAGE_COUNT = 12;

            var complexModelPages = new Dictionary<int, ComplexModel>();

            for (int i = 0; i < DEFAULT_PAGE_COUNT; i++)
            {
                int pageNumber = i + 1;

                var complexModel = new ComplexModel();

                complexModelPages.Add(pageNumber, complexModel);
            }

            return complexModelPages;
        }
    }

    public class Dict1Object
    {
        public decimal? Dict1ObjDec1 { get; set; }
        public decimal? Dict1ObjDec2 { get; set; }
    }
}
