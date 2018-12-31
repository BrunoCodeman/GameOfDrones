import { TestBed, inject } from '@angular/core/testing';

import { ScoresComponent } from './Scores.component';

describe('a Scores component', () => {
	let component: ScoresComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				ScoresComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([ScoresComponent], (ScoresComponent) => {
		component = ScoresComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});