namespace GrowthDiary.ViewModel
{
    public class BaseViewModel
    {
    }

    public class BaseSearchViewModel
    {
        public bool IsPagination { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }

    }
}
