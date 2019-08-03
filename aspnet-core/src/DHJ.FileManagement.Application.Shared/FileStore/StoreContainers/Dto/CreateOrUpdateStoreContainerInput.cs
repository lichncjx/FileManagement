namespace DHJ.FileManagement.FileStore.StoreContainers.Dto
{
    public class CreateOrUpdateStoreContainerInput
    {
        public int? FatherContainerId { get; set; }
        public StoreContainerEditDto StoreContainer { get; set; }
    }
}