_parent(idx) {
        return Math.floor(idx / 2);
    }

    _leftChild(idx) {
        return idx * 2;
    }

    _rightChild(idx) {
        return idx * 2 + 1;
    }

    _isPresent(idx) {
        return idx <= this.size();
    }

    _swap(i, j) {
        [this._heap[i], this._heap[j]] = [this._heap[j], this._heap[i]];
    }