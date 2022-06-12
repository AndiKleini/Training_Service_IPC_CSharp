# Training_Service_IPC_CSharp
This repository is meant as a training example for establishing IPC between two service. Therefore a meetingplanner service is checking the availability of attendees 
by communicating with a timeslot service. Both apps are realized as .net core REST apis.

## scenario for meeting is possible
In order to determine whether a meeting is possible following steps are passed:
1.) The meetintplanner service is invoked by specifying time and attendees.
2.) For each attendee the meetingplanner queries the timeslot service for already reserved timeslots of the attendee.
3.) The meetingplaner verfies if all attendees are free by checking timeslots received from timeslot service.
4.) If and only if all attendees have time the meeting planner returns true for the ispossible property in it's response. Otherwise false.

## launch the system
Before you can watch the communication between the service you have to bring up both apps. Therefore open the solution in Visual Studio.

### launch timeslot service
Just run the timeslot service (project TimeSlot) in Debug mode.

You can test the api with 
http://localhost:6002/timeslot/1?from=2022-05-11T15:43&to=2022-07-11T18:53
and you will receive:
```JSON
[
  {
    "ownerId":1,
    "from":"2022-06-11T15:43:00",
    "to":"2022-06-11T16:43:00"
  },
  {
    "ownerId":1,
    "from":"2022-06-11T17:43:00",
    "to":"2022-06-11T18:43:00"
  },
  {
    "ownerId":1,
    "from":"2022-06-11T19:43:00",
    "to":"2022-06-11T19:53:00"
  }
]
```

### launch meetingplanner service
Just run the MeetingPlanner service (project meetingplanner) in DEBUG mode.

You can test the api with 
http://localhost:5001/meeting/ispossible?attendees=1&attendees=2&from=2022-06-11T15:43&to=2022-06-11T18:53
and you will receive:
```JSON
{
  "possible":false
}
```

Please be aware that meetingplanner service depends on the timeslot service, so that the availability of the latter is required.
