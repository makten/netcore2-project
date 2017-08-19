
<script>
	export default {

		props: { 
			modalname: { required: true, default: 'default-modal' },
			isDashboard: { required: false, default: false },
			width: {required: false, default: 50}
	},

		data() {
			return {

				styleObject: {
					 width: this.width + '%',
					 background: '#24303a',

				}

			}
		},


		mounted() {
			
			this.$nextTick(function(){		
			
				$(`#${this.modalname}`).modal('show'); 

				$(`#${this.modalname}`).modal({
					backdrop: 'static',
					keyboard: true
				})

				$(`#${this.modalname}`).on("hidden.bs.modal", function () {

					eventBroadcaster.$emit('closeModal')
				});

			});
		},

		methods: {

		},

		computed() {

		}

	}
</script>

<template>
	
	<div>

		<div class="modal fade" :id="modalname" tabindex="-1" role="dialog" data-backdrop="static" 
		data-keyboard="false">

		<div class="modal-dialog modal-lg" :style="styleObject">

			<div class="modal-content" :class="{'mini-dashboard': isDashboard}">

				<div class="modal-header">
					<button @click="$emit('closeModal')" type="button" class="close btn-danger" data-dismiss="modal" aria-hidden="true">&times;</button>

					<h5 class="modal-title"> 
						<slot name='title'></slot>
					</h5>

				</div>

				<div class="modal-body">

					<slot name='body'></slot>

				</div>


				<div class="modal-footer">

					<slot name='footer'></slot>
					<button @click="$emit('closeModal')" type="button" class="btn btn-xs btn-default" data-dismiss="modal">Close</button>

				</div>

			</div>
		</div>
	</div>

</div>
</template>

<style lang='sass'>

	.mini-dashboard {
		background: #24303a;

	}

	.smallchart {
		color: #4a667a !important;
    /*text-align: left;
    position: relative;
    height: auto;*/
    background-color: #1e2730 !important;
    /*display: inline-block;
    float: left;
    position: relative;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    margin: 10px;
    padding: 15px 20px 65px 20px;*/
}


/*@media screen and (min-width: 700px)*/
/*.chart {
    width: calc(50% - 20px);
}*/



</style>
