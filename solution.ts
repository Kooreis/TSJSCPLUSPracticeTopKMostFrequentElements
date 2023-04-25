shiftUp(i: number) {
        while (i > 0 && this.heap[this.parent(i)][1] < this.heap[i][1]) {
            this.swap(i, this.parent(i));
            i = this.parent(i);
        }
    }

    shiftDown(i: number) {
        while (
            this.left(i) < this.heap.length &&
            (this.heap[i][1] < this.heap[this.left(i)][1] ||
                (this.right(i) < this.heap.length && this.heap[i][1] < this.heap[this.right(i)][1]))
        ) {
            let tmp = this.left(i);
            if (this.right(i) < this.heap.length && this.heap[tmp][1] < this.heap[this.right(i)][1]) {
                tmp = this.right(i);
            }
            this.swap(i, tmp);
            i = tmp;
        }
    }