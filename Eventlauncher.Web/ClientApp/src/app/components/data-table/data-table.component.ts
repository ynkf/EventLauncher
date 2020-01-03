import { ComputerService } from './../../services/computer.service';
import { RoomService } from './../../services/room.service';
import { Room } from './../../models/room.model';
import { Component, OnInit } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { isNil, isEmpty } from 'lodash';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html'
})
export class DataTableComponent implements OnInit {

  // @Input()
  rooms: Room[];

  constructor(private roomService: RoomService, private computerService: ComputerService) { }

  ngOnInit() {
    let r1 = new Room();
    r1.roomDesignation = 'raum1';
    r1.roomMailAdress = 'raum1@mail.ch';
    r1.computerId = 1;

    let r2 = new Room();
    r2.roomDesignation = 'raum2';
    r2.roomMailAdress = 'raum2@mail.ch';
    r2.computerId = 2;

    this.roomService
      .getRooms()
      .pipe(catchError(err => {
        console.log('TODO: ErrorHandling: ' + err);
        return [] as Room[][];
      }))
      .subscribe(rooms => {
        console.log(rooms);
        this.rooms = (rooms as Room[]);
        // this.rooms.push(r1);
        // this.rooms.push(r2);
      });

    // this.roomService
    //   .getRooms()
    //   .subscribe(rooms => {
    //     console.log(rooms);
    //     this.rooms = rooms;
    //     console.log(this.rooms);
    //     // this.computerService
    //     // .getComputers()
    //     // .subscribe(computers =>
    //     //   computers.map(c => {
    //     //     this.data.forEach(d => d.computer = d.computerId === c.id ? c : null);
    //     //     console.log(computers);
    //     //     console.log(this.data); }
    //     //   )
    //     // );
    //   });
  }
}
