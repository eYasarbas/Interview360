namespace Interview360.Domain.Enums
{
    public enum PostStatus
    {
        Draft = 0,    
        Pending = 1,    
        Approved = 2,    
        Rejected = 3,   
        Archived = 4,  
        Deleted = 5       
    }

    public enum MediaType
    {
        None = 0,
        Image = 1,
        Video = 2
    }

    public enum MediaFormat
    {
        None = 0,
        Jpg = 1,
        Png = 2,
        Gif = 3,
        Mp4 = 4,
        WebM = 5
    }
}