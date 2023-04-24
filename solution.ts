class MaxHeap {
    heap: [number, number][];
    constructor() {
        this.heap = [];
    }

    swap(i: number, j: number) {
        [this.heap[i], this.heap[j]] = [this.heap[j], this.heap[i]];
    }

    parent(i: number): number {
        return (i - 1) >> 1;
    }

    left(i: number): number {
        return 2 * i + 1;
    }

    right(i: number): number {
        return 2 * i + 2;
    }
}