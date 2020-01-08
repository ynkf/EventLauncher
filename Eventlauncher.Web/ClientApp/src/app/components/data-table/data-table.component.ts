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
  @Output()
  updateEvent = new EventEmitter<Room>();

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

  edit(room: Room): void {
    this.rooms.find(r => r.id === room.id).isEdit = true;
  }

  cancel(room: Room): void {
    if (isNil(room.id)) {
      this.rooms = this.rooms.filter(r => r.id !== room.id);
    } else {
      this.rooms.find(r => r.id === room.id).isEdit = false;
    }

    this.isAnyInEdit();
  }

  createOrUpdate(room: Room): void {
    isNil(room.id)
      ? this.create(room)
      : this.update(room);
  }

  private create(room: Room): void {
    this.createEvent.emit(room);
    this.isAnyInEdit();
  }

  private update(room: Room): void {
    this.updateEvent.emit(room);
    this.isAnyInEdit();
  }

  private isNilOrEmpty(value: string): boolean {
    return isNil(value) || isEmpty(value);
  }
}
