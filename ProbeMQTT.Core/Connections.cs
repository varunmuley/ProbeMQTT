using MQTTnet;
using MQTTnet.Core;
using MQTTnet.Core.Client;
using MQTTnet.Core.ManagedClient;
using ProbeMQTT.Database;
using ProbeMQTT.Interfaces;
using ProbeMQTT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProbeMQTT
{
    public sealed class Connections
    {

        public List<Connection> ConnectionList { get; set; }
        public IManagedMqttClient mqttclient { get; set; }

        static ConnectionDatabase db;

        private static readonly Lazy<Connections> lazy = new Lazy<Connections>(() => new Connections());

        public static Connections Instance { get { return lazy.Value; } }

        private Connections()
        {
            InitializeDatabase();

        }

        private static void InitializeDatabase()
        {
            db = new ConnectionDatabase();
        }

        private async Task Connect(Connection c)
        {
            if (mqttclient == null)
            {
                MqttFactory mqttFactory = new MqttFactory();
                mqttclient = mqttFactory.CreateManagedMqttClient();
                mqttclient.ApplicationMessageReceived += Mqttclient_ApplicationMessageReceived;
                mqttclient.Connected += Mqttclient_Connected;
                mqttclient.Disconnected += Mqttclient_Disconnected;

                try
                {
                    await mqttclient.StartAsync(new ManagedMqttClientOptions()
                    {
                        ClientOptions = new MqttClientOptions()
                        {
                            ChannelOptions = new MqttClientTcpOptions()
                            {
                                Server = c.Uri,
                                Port = c.Port
                            },
                            ClientId = c.ClientId
                        },
                        AutoReconnectDelay = TimeSpan.FromSeconds(1)

                    });
                    //DependencyService.Get<IToastHelper>().ShortAlert("Connected!");
                }

                catch (Exception ee)
                {

                }

            }
        }

        private void Mqttclient_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Mqttclient_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Mqttclient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public static void SaveConnection(Connection c)
        {
            db.ConnectDatabase().InsertAsync(c);
        }

        public async static void DeleteConnection(Connection c)
        {
            var result = await db.ConnectDatabase().DeleteAsync(c);
        }


        public async static void CreateClientConnection(Connection c)
        {
            try
            {
                await Connections.Instance.Connect(c);

            }
            catch (Exception e)
            {
                DependencyService.Get<IToastHelper>().ShortAlert("Error Connecting!");
            }
        }

        public Task<List<Connection>> GetConnections()
        {
            return db.ConnectDatabase().Table<Connection>().ToListAsync();
        }

    }
}
