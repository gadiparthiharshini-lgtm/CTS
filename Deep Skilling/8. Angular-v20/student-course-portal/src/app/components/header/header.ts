import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class Header {

  @Input()
  title: string = '';

  @Output()
  homeClicked = new EventEmitter<string>();

  onHomeClick() {
    this.homeClicked.emit('Home menu clicked!');
  }

}