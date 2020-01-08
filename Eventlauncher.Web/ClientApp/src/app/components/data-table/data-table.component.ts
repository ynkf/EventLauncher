import { Room } from './../../models/room.model';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { isNil, isEmpty } from 'lodash';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html'
})
export class DataTableComponent {

  @Input()
  rooms: Room[];

  @Output()
  isAnyDataInEdit = new EventEmitter<boolean>();
  @Output()
  createEvent = new EventEmitter<Room>();

  isAnyInEdit(): boolean {
    if (this.rooms) {
      const b = this.rooms.some(r => r.isEdit);
      this.isAnyDataInEdit.emit(b);
      return b;
    }

    return false;
  }

  isValidRoom(room: Room): boolean {
    return !(this.isNilOrEmpty(room.computer.ipAddress)
      && this.isNilOrEmpty(room.roomMailAddress));
  }

  cancel(room: Room): void {
    this.rooms = this.rooms.filter(r => r.id !== room.id);
    this.isAnyInEdit();
  }

  create(room: Room): void {
    this.createEvent.emit(room);
    this.isAnyInEdit();
  }

  private isNilOrEmpty(value: string): boolean {
    return isNil(value) || isEmpty(value);
  }
}
