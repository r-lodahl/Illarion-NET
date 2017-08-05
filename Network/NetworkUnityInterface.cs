using System;
using System.Collections.ObjectModel;
using Illarion.Common.Character;
using Illarion.Common.Chat;
using Illarion.Common.Internal.Communication;
using Illarion.Common.Internal.Communication.Commands;
using Illarion.Common.System;
using Illarion.Network.Core;
using Illarion.Network.Core.Interfaces;
using UnityEngine;

namespace Illarion.Network
{
    public class NetworkUnityInterface : MonoBehaviour, ISubscribable
    {
        private UnityConnection _connection;
        public event EventHandler EventMessage;

        void Awake()
        {
            EventManager.Publish(Command.CmdLogin, this);

            _connection = new UnityConnection("localhost", 13000, new DebugReceiver());
            ConnectAndLogin();
        }

        private async void ConnectAndLogin()
        {
            await _connection.ConnectAsync();
            if (EventMessage != null) EventMessage.Invoke(this, new LoginCommandEventArgs("Testserver One", "test"));
            //await _connection.Login("Testserver One", "test");
        }


        class DebugReceiver : IReceiver
        {
            private ObservableCollection<string> Characters { get; set; }

            public void LoginSuccessful()
            {
                Debug.Log("Login OK!");
            }

            public void Action(CharacterId characterId, MessageType messageType, string message)
            {
                //Throw New NotImplementedException()
            }

            public void SkillChanged(CharacterId characterId, byte skillId, short value, short minor)
            {
                // Throw New NotImplementedException()
            }

            public void AttributeChanged(CharacterId characterId, CharacterAttribute attribute, short value)
            {
                //Throw New NotImplementedException()
            }

            public void Logout(CharacterId characterId)
            {
                // Throw New NotImplementedException()
            }

            void IReceiver.LogoutPlayer(CharacterId characterId)
            {
                Logout(characterId);
            }

            public void Logout(LogoutReason reason)
            {
                Console.WriteLine("Logout :/ " + Enum.GetName(typeof(LogoutReason), reason));
            }

            public void NewPlayer(CharacterId characterId, string name, Coordinate coordinate)
            {
                Characters.Add(name);
            }

            public void PlayerMoved(CharacterId characterId, Coordinate coordinate)
            {
                //  Throw New NotImplementedException()
            }

            public void Message(string message, MessageType messageType)
            {
                //Throw New NotImplementedException()
            }

            public void Talk(CharacterId characterId, TalkType talkType, string message)
            {
                // Throw New NotImplementedException()
            }
        }


    }
}
