﻿using WebApplication2.Models;

namespace WebApplication2.IRepository
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExists(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);


        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int CommandId);
        void CreateCommand(int platformId, Command command);




    }
}