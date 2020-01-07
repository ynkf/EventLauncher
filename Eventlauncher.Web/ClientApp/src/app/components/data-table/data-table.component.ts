import { Room } from './../../models/room.model';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html'
})
export class DataTableComponent {
  @Input()
  rooms: Room[];
}
