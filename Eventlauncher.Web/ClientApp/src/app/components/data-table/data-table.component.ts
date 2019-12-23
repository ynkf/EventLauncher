import { ComputerService } from './../../services/computer.service';
import { RoomService } from './../../services/room.service';
import { Room } from './../../models/room.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html'
})
export class DataTableComponent implements OnInit {

  // @Input()
  data: Room[];

  constructor(private roomService: RoomService, private computerService: ComputerService) { }

  ngOnInit() {
    this.roomService
      .getRooms()
      .subscribe(rooms => {
        this.data = rooms;
        console.log(this.data);
        // this.computerService
        // .getComputers()
        // .subscribe(computers =>
        //   computers.map(c => {
        //     this.data.forEach(d => d.computer = d.computerId === c.id ? c : null);
        //     console.log(computers);
        //     console.log(this.data); }
        //   )
        // );
      });
  }

}
