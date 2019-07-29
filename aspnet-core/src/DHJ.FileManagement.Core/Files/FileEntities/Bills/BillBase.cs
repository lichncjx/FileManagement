namespace DHJ.FileManagement.Files.FileEntities.Bills
{
    public class BillBase : FileBase
    {
        public int TotalPages { get; set; }

        public int PageIndex { get; set; }
    }
}