using Microsoft.AspNetCore.SignalR;
using KKOK_WEB.CommDB;

namespace KKOK_WEB.CommHub
{
    public class CommHub_Project : Hub
    {
        CommDB_PROJECT commDB = new CommDB_PROJECT();
        public async Task SendMessage(string data, int func_num)
        {
            //처리
            switch(func_num)
            {
                case (int)DB_PROJECT_FUNC_NAME.DB_SELECT_QUERY_PROJECT:
                    {
                        commDB.db_Select_Query(data);
                        await Clients.Caller.SendAsync("ReceiveMessage", commDB.result, func_num); //전송
                    }
                    break;
                case (int)DB_PROJECT_FUNC_NAME.DB_INSERT_QUERY_PROJECT:
                    {
                        commDB.db_Insert_Query(data);
                    }
                    break;
                case (int)DB_PROJECT_FUNC_NAME.DB_UPDATE_QUERY_PROJECT:
                    {
                        commDB.db_Update_Query(data);
                    }
                    break;
                case (int)DB_PROJECT_FUNC_NAME.DB_DELETE_QUERY_PROJECT:
                    {
                        commDB.db_Delete_Query(data);
                    }
                    break;
            }
            //
        }

    }
}


