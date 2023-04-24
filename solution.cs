class PriorityQueue {
    constructor(comparator = (a, b) => a > b) {
        this._heap = [null];
        this._comparator = comparator;
    }

    size() {
        return this._heap.length - 1;
    }

    isEmpty() {
        return this.size() === 0;
    }

    peek() {
        if (this.isEmpty()) return null;
        return this._heap[1];
    }

    push(value) {
        this._heap.push(value);
        this._siftUp();
    }

    pop() {
        if (this.isEmpty()) return null;
        const poppedValue = this._heap[1];
        const bottom = this.size();
        if (bottom > 1) {
            this._swap(1, bottom);
        }
        this._heap.pop();
        this._siftDown();
        return poppedValue;
    }
}