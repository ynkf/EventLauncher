import { RoomService } from './../../services/room.service';
import { ComputerService } from './../../services/computer.service';
import { Room } from './../../models/room.model';
import { Component, OnInit } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Computer } from 'src/app/models/computer.model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  rooms: Room[];

  constructor(
    private computerService: ComputerService,
    private roomService: RoomService,
  ) {}

  ngOnInit(): void {
    this.roomService
      .getRooms()
      .pipe(catchError(err => {
        console.log('TODO: ErrorHandling: ' + err);
        return [] as Room[][];
      }))
      .subscribe(rooms => {        
        this.rooms = rooms;
        this.computerService
          .getComputers()
          .pipe(catchError(err => {
            console.log('TODO: ErrorHandling: ' + err);
            return [] as Computer[][];
          }))
          .subscribe(computers =>
            this.rooms = this.rooms.map(r => {
              r.computer = computers.find(c => r.computerId === c.id);              
              return r;
          }));
      });
  }
}
