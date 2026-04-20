using ABC_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_University.Controllers
{
    public class RoomController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();
        public ActionResult Index()
        { 
            List<Room> roomLst = new List<Room>();
            roomLst = (from room in myDB.rooms
                       select room).ToList();

            return View(roomLst);
        }

        public ActionResult GetDetails(int id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == id
                   select room).FirstOrDefault();

            return View("RoomDetails",obj);
        }

        public ActionResult DeleteRoom( int roomID)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == roomID
                   select room).FirstOrDefault();
            myDB.rooms.Remove(obj);
            myDB.SaveChanges();
            return View("Index");
        }

        public ActionResult UpdateRoom(int roomID)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == roomID
                   select room).FirstOrDefault();
            obj.roomName = "New Room Name";
            myDB.SaveChanges();
            return View("Index");
        }

        public ActionResult InsertRoom()
        {
            Room obj = new Room();
            obj.isAvailable = true;
            obj.location = "Strret 1";
            obj.roomSize = 1005;
            obj.roomName = "My Room";

            myDB.rooms.Add(obj);
            myDB.SaveChanges();
            return View("Index");

        }
    }
}