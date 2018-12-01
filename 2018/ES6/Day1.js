const fs = require('fs');

class Part1{
    constructor(input){
        this.Frequency = 0;
        this.Input = input;
    }

    answer(){
        this.Input.map(n => this.Frequency += parseInt(n));
        return this.Frequency;
    }
}

class Part2 {
    constructor(input){
        this.Frequency = 0;
        this.RecurringFrequencyFound = false;
        this.RecurringFrequency = 0;
        this.SeenFrequencies = [0];
        this.Input = input;
    }

    answer(){
        while(!this.RecurringFrequencyFound){
            this.Input.map(n => this.check(n));
        }

        return this.RecurringFrequency;
    }

    check(frequency){
        this.Frequency += parseInt(frequency);

        if(!this.RecurringFrequencyFound && this.SeenFrequencies.includes(this.Frequency)){
            this.RecurringFrequencyFound = true;
            this.RecurringFrequency = this.Frequency;
        }

        this.SeenFrequencies.push(this.Frequency)
    }
}

class Reader{
    constructor(path){
        this._path = path;
    }

    getFormattedInput(){
        const values = fs.readFileSync(this._path)
        .toString()
        .split('\n')
        .map(s => s.replace(/\r$/, ''))
        .filter(s => s.length > 0);

        return values;
    }
}

const reader = new Reader('Day1Input.txt');

// const puzzle = new Part1(reader.getFormattedInput()); // 543
const puzzle = new Part2(reader.getFormattedInput()); // 621

console.log(puzzle.answer());
