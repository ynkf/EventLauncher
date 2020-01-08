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

  isInEdit = false;

  constructor(
    private computerService: ComputerService,
    private roomService: RoomService
  ) {}

  getData(): void {
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

  addData(): void {
    this.rooms.push(new Room(true));
  }

  createData($event: Room) {
    this.computerService
      .createComputer($event.computer)
      .pipe(catchError(err => {
        console.log('TODO: ErrorHandling: ' + err);
        return [] as Computer[];
      }))
      .subscribe(c => {
        $event.computerId = c.id;
        this.roomService
          .createRoom($event)
          .pipe(catchError(err => {
            console.log('TODO: ErrorHandling: ' + err);
            return [] as Room[];
          }));
      });

    this.getData();
  }

  isAnyDataInEdit($event: boolean): void {
    this.isInEdit = $event;
  }

  ngOnInit(): void {
    this.getData();
  }
}
