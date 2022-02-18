namespace DoctorFinder.EDM
{
    public interface ISessionManage
    {
        string currentUserName { get; set; }
        bool hasSession { get; set; }
        string userEmail { get; set; }

        TblAdmin GetSession();
        void SetSession(TblAdmin tblAdmin);
        void KillSession();
    }
}