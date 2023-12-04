namespace ParallelAccessToServer.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ParallelAccessToServer_moreAccess_success()
        {
            try
            {
                var task1 = Task.Run(() => Server.GetCount());

                Task.Run(() => Server.AddToCount(1));

                var task2 = Task.Run(() => Server.GetCount());

                Task.Run(() => Server.AddToCount(1));
                Task.Run(() => Server.AddToCount(-2));

                var task3 = Task.Run(() => Server.GetCount());

                Task.Run(() => Server.AddToCount(4));

                var task4 = Task.Run(() => Server.GetCount());

                Task.Run(() => Server.AddToCount(-8));

                var task5 = Task.Run(() => Server.GetCount());
                var task6 = Task.Run(() => Server.GetCount());
                var task7 = Task.Run(() => Server.GetCount());

                Task.WaitAll();

                Assert.Equal(0, task1.Result);
                Assert.Equal(1, task2.Result);
                Assert.Equal(0, task3.Result);
                Assert.Equal(4, task4.Result);
                Assert.Equal(-4, task5.Result);
                Assert.Equal(-4, task6.Result);
                Assert.Equal(-4, task7.Result);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }
    }
}