using System;

namespace кубик{
    class Program{
        class Classroom{
            int seatsCount;
            bool hasProjector;
            bool hasPC;
            int building;
            string numberOfClassroom;
            public Classroom(int seatsCount, bool hasProjector, bool hasPC, int building, string numberOfClassroom){
                this.seatsCount = seatsCount;
                this.hasProjector = hasProjector;
                this.hasPC = hasPC;
                this.building = building;
                this.numberOfClassroom = numberOfClassroom;
            }
        }
        static void Main(string[] args){

        }
    }
}