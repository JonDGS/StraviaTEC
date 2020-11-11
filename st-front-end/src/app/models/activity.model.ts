//: Date, time, duration, type, km, GPX, Is it an activity, challenge or race

export class Activity{
    constructor(
        public date : Date,
        public time : string,
        public duration : string,
        public type : string,
        public km : string,
        public GPX : string,
        public classification : string,
    ){

    }
}