.PHONY: all
.PHONY: install
.PHONY: clean

ISP_PREFIX ?= /opt/isp/

all: output/.built

FILES := $(shell find -name "*" -type f -not -path "./output/*" -not -path "*/bin/*" -not -path "*/obj/*" | sed 's/ /\\ /g')
output/.built: $(FILES)
	./build.sh
	cd src/Infrastructure; git checkout dover
	$(MAKE) clean
	./build.sh
	touch $@

install: all
	DIR=$(ISP_PREFIX)renode TARGET="Release" BASE=. bash tools/packaging/common_copy_files.sh
	sed s%/opt/%$(ISP_PREFIX)%g tools/packaging/linux/renode.sh > $(ISP_PREFIX)bin/renode
	chmod +x $(ISP_PREFIX)bin/renode


clean:
	$(RM) -r $(ISP_PREFIX)bin/renode
	$(RM) -r $(ISP_PREFIX)renode
	./build.sh -c
	$(RM) -r output
