import { ElementRef } from '@angular/core';
import { Highlight } from './highlight';

describe('Highlight', () => {

  it('should create an instance', () => {

    const mockElement = new ElementRef(document.createElement('div'));

    const directive = new Highlight(mockElement);

    expect(directive).toBeTruthy();

  });

});