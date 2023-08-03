namespace TodoWebApp_Server_v2.Dtos
{
    public class ResponseObjectDto
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object objectData { get; set; }

        public bool IsSuccess()
        {
            if(status) return true;
            else return false;
        }
        public ResponseObjectDto( string message, bool status = false )
        {
            this.status = status;
            this.message = message;
        }
        public ResponseObjectDto( string message, object objectData, bool status = false )
        {
            this.status = status;
            this.message = message;
            this.objectData = objectData;
        }
    }
}
