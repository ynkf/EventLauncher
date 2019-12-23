import { RoomService } from './../../services/room.service';
import { ComputerService } from './../../services/computer.service';
import { Room } from './../../models/room.model';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  data: Room[];

  constructor(
    private computerService: ComputerService,
    private roomService: RoomService,
  ) {}

  ngOnInit(): void {
  }

  addClick($event: any) {

  }
}
