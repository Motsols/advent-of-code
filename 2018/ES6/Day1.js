const fs = require('fs');

class Part1{
    constructor(input){
        this.Frequency = 0;
        this.Input = input;
    }

    answer(){
        this.iterate();
        return this.Frequency;
    }

    iterate(){
        this.Input.forEach(frequency => {
            this.Frequency += parseInt(frequency);
        });
    }
}

class Part2 {
    constructor(input){
        this.Frequency = 0;
        this.RecurringFrequencyFound = false;
        this.RecurringFrequency = 0;
        this.Input = input;
    }

    answer(){
        this.iterate();
        return this.RecurringFrequency;
    }

    iterate(){
        let seenFrequencies = [0];
        while(!this.RecurringFrequencyFound){
            this.Input.forEach(frequency => {
                this.Frequency += parseInt(frequency);

                if(!this.RecurringFrequencyFound && seenFrequencies.includes(this.Frequency)){
                    this.RecurringFrequencyFound = true;
                    this.RecurringFrequency = this.Frequency;
                }
    
                seenFrequencies.push(this.Frequency);
            });
        }
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

// const puzzle = new Part1(reader.getFormattedInput());
const puzzle = new Part2(reader.getFormattedInput());

console.log(puzzle.answer());
