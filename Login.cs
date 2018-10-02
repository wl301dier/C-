        private void btnok_Click(object sender, EventArgs e)
        {
            int count = 0;
            string username = txtusername.Text;//用户名
            string password = txtpassword.Text;//密码

            //连接dormitory数据库
            SqlConnection conn = new SqlConnection();//建立连接对象
            conn.ConnectionString = "data source =.;user id = sa; password = 123456; initial catalog = dormitory";//连接字符串
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接数据库，请检查网络连接！");
                //MessageBox.Show(ex.StackTrace);
                return;
            }

            //从userinfo表中,验证用户名和密码信息是否正确
            SqlCommand cmd = new SqlCommand();//建立命令对象
            cmd.CommandText = "select count(*) from userinfo where username = @username and password = @password";
            cmd.Parameters.AddWithValue("@username",username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = conn;

            //执行SQL语句
            try
            {
                count = (int)cmd.ExecuteScalar();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                conn.Close();
                return;
            }
            conn.Close();

            //判断
            if (count > 0)//如果结果>0，则认为用户名和密码正确
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("登录成功，欢迎访问宿舍管理系统\n\tDevelop by 王亮");
            }
            else //登录错误
            {
                MessageBox.Show("用户名或密码输入错误！");
            }
        }
