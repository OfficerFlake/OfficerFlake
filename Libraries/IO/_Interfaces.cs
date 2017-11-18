namespace Com.OfficerFlake.Libraries.IO
{
    public interface IReadable
    {
        byte[] ReadAll();
    }
    public interface IWriteable
    {
        bool Write(byte[] data);
    }

    public interface IEraseable
    {
        bool Erase();
    }

    public interface ILoadable
    {
        bool Load();
    }
    public interface ISaveable
    {
        bool Save();
    }
}
