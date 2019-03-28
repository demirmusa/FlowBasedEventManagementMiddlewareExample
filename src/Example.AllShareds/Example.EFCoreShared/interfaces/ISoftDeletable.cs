

namespace Example.EFCoreShared.interfaces
{
    internal interface ISoftDeletable: IBaseDbEntity
    {
        bool Deleted { get; set; }
    }
}
