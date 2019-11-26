import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MeetingRoom } from '../models/MeetingRoom.model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  mockdata: MeetingRoom[];

  ngOnInit(): void {
    let mr = new MeetingRoom();
    mr.email = 'eventlauncher@gmail.com';
    mr.name = 'EventlauncherRoom';
    mr.ip = '192.164.08.56';
    this.mockdata = [mr];
  }
}
