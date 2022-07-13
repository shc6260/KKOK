using Microsoft.AspNetCore.SignalR;
using KKOK_WEB.CommDB;

namespace KKOK_WEB.CommHub
{
    public class CommHub_Base : Hub
    {
        CommDB_Base commDB = new CommDB_Base();  // DB 연결 클래스 생성
        /// <summary>
        /// 서버에 SendMessage가 호출이 되면 실행되는 함수
        /// </summary>
        /// <param name="data">들어오는 Json 형식의 문자열 값</param>
        /// <param name="func_num">실행할 함수 번호</param>
        /// <returns></returns>
        public async Task SendMessage(string data, int func_num) // sendmessage 호출시 실행
        {
            //처리
            switch(func_num)
            {
                case (int)DB_BASE_FUNC_NAME.DB_SELECT_QUERY_BASE:
                    {
                        commDB.db_Select_Query_Base(data);
                        await Clients.Caller.SendAsync("ReceiveMessage", data, func_num); //요청자에게 전송 
                    }
                    break;
                case (int)DB_BASE_FUNC_NAME.DB_INSERT_QUERY_BASE:
                    {
                        commDB.db_Insert_Query_Base(data);
                    }
                    break;
                case (int)DB_BASE_FUNC_NAME.DB_UPDATE_QUERY_BASE:
                    {
                        commDB.db_Update_Query_Base(data);
                    }
                    break;
                case (int)DB_BASE_FUNC_NAME.DB_DELETE_QUERY_BASE:
                    {
                        commDB.db_Delete_Query_Base(data);
                    }
                    break;
            }
            //
        }

    }
}


