using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHappyHouse
{
    public partial class Form1 : Form
    {
        Location currentLocation;

        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;

        public Form1()
        {
            InitializeComponent();
            CreatObjects();
            Console.WriteLine(livingRoom.Description);
            MoveToANewLocation(livingRoom);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreatObjects()
        {
            livingRoom = new RoomWithDoor("客厅","一个水晶吊灯","一扇带有金色把手的门");
            diningRoom = new Room("餐厅","四人餐桌");
            kitchen = new RoomWithDoor("厨房","冰箱微波炉煤气灶","手拉玻璃门");

            frontYard = new OutsideWithDoor("前院",false,"一扇木门");
            backYard = new OutsideWithDoor("后院",true,"一扇又大又高的铁门");
            garden = new Outside("花园",false);

            diningRoom.Exits = new Location[] {livingRoom,kitchen};
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };

            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;
            //Console.WriteLine(currentLocation.Name);
            //Console.WriteLine(currentLocation.Description);

            exits.Items.Clear();

            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;
            //Console.WriteLine(description.Text);
            //Console.ReadLine();

            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }
    }
}
