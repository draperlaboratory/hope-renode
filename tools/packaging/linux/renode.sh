#!/bin/bash

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

mono $MONO_OPTIONS $SCRIPT_DIR/../renode/bin/Renode.exe "$@"
