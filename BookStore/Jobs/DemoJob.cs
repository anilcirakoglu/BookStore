using Npgsql;
using Quartz;
namespace BookStore.Jobs
{
    //    public class DemoJob : IJob
    //    {
    //        public Task Execute(IJobExecutionContext context)
    //        {

    //            using (PgSqlCommand cmd = new PgSqlCommand())
    //            {
    //                cmd.CommandText = "INSERT INTO public.demo " +
    //                    "(id, message) VALUES(@id, @message)";

    //                cmd.Connection = pgSqlConnection;
    //                cmd.Parameters.AddWithValue("id", id);
    //                cmd.Parameters.AddWithValue("name", message);

    //                if (pgSqlConnection.State != System.Data.ConnectionState.Open)
    //                    pgSqlConnection.Open();
    //                cmd.ExecuteNonQuery();
    //            }
    //            return Task.FromResult(true);
    //        }
    //    }

    //}
}