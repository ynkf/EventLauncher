import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MeetingRoom } from '../../models/MeetingRoom.model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  mockdata: MeetingRoom[];

  ngOnInit(): void {
    const mr1 = new MeetingRoom();
    mr1.email = 'eventlauncher@gmail.com';
    mr1.name = 'EventlauncherRoom';
    mr1.ip = '192.164.08.56';

    const mr2 = new MeetingRoom();
    mr2.email = 'eventlauncher2@gmail.com';
    mr2.name = 'EventlauncherRoom2';
    mr2.ip = '192.164.08.69';
    this.mockdata = [mr1, mr2];
  }
}
