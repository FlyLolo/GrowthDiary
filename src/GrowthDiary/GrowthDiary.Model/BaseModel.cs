namespace GrowthDiary.Model
{
public class BaseModel
{
    //[BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }
}

public class BaseSearchModel
{
    public bool IsPagination { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int RecordCount { get; set; }

}
}
