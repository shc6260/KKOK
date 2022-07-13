using Microsoft.AspNetCore.SignalR.Client;

namespace KKOK_WEB.ClientHub_Base
{
    public class Client_SignalRHub
    {
        HubConnection connection;

        public Client_SignalRHub()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7216/chatHub") // 주소
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync(); 
            }; //연결 끊길 경우 재연결
        }

        public async void conn() // 연결
        {
            connection.On<string, int>("ReceiveMessage", (data, func_num) =>
            {
                // 내부 처리
            });// 지정된 메서드 이름을 가진 허브 메서드가 호출될 때 호출될 처리기를 등록.
            try
            {
                await connection.StartAsync();
                //MessageBox.Show("Connection started");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// sendmessage 호출
        /// </summary>
        /// <param name="data">Json 형식의 문자열 값</param>
        /// <param name="func_num">실행할 함수 번호</param>
        public async void send(string data, int func_num)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    data, func_num);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
