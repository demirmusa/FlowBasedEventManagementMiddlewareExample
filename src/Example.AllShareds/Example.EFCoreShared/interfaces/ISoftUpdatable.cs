


namespace Example.EFCoreShared.interfaces
{
    internal interface ISoftUpdatable : ISoftDeletable
    {
        int? FKPreviousVersionID { get; set; }
    }
}
